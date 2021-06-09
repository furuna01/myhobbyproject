<?php

class EncodeDecode {

    private $key = "aaaaxxxx";
    public function Encode($string) {
        return openssl_encrypt($string, 'AES-128-ECB', $key);
    }
    public function Decode($string) {
        return openssl_decrypt($string, 'AES-128-ECB', $key);
    }
}
?>