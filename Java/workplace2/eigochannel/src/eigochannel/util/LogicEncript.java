package eigochannel.util;

import java.security.GeneralSecurityException;
import java.security.NoSuchAlgorithmException;
import java.security.SecureRandom;

import javax.crypto.Cipher;
import javax.crypto.KeyGenerator;
import javax.crypto.SecretKey;
import javax.crypto.spec.IvParameterSpec;

public class LogicEncript {

	/**
	 * 共通鍵を生成する
	 * @return 共通鍵
	 * @throws NoSuchAlgorithmException
	 */
	private SecretKey generateKey() throws NoSuchAlgorithmException {
		KeyGenerator keyGen = KeyGenerator.getInstance("AES");
		keyGen.init(128);

		return keyGen.generateKey();
	}

	private IvParameterSpec generateIV() {

		SecureRandom random = new SecureRandom();
		byte[] iv = new byte[16];
		random.nextBytes(iv);

		return new IvParameterSpec(iv);
	}

	public byte[]  EncripString(String text) throws GeneralSecurityException {
		Cipher encrypter = Cipher.getInstance("AES/CBC/PKCS5Padding");
		SecretKey key = this.generateKey();
		IvParameterSpec iv = this.generateIV();
		encrypter.init(Cipher.ENCRYPT_MODE, key, iv);

		return encrypter.doFinal(text.getBytes());
	}

	public String DecripByte(byte[] crypText) throws GeneralSecurityException {
		// 書式:"アルゴリズム/ブロックモード/パディング方式"
        Cipher decrypter = Cipher.getInstance("AES/CBC/PKCS5Padding");
		SecretKey key = this.generateKey();
		IvParameterSpec iv = this.generateIV();

        decrypter.init(Cipher.DECRYPT_MODE, key, iv);

        return new String(decrypter.doFinal(crypText));
    }
}
