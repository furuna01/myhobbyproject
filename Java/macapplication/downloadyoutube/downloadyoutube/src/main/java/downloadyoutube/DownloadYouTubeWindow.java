package downloadyoutube;

import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLConnection;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JTextField;

public class DownloadYouTubeWindow extends JFrame implements ActionListener {

	private JTextField textField = new JTextField(50);
	private JButton downloadButton = new JButton("ダウンロード");
	private final int WINDOW_SIZE_WIDTH = 600;
	private final int WINDOW_SIZE_HEIGHT = 300;
	public DownloadYouTubeWindow() {
		getContentPane().setLayout(new FlowLayout());
		getContentPane().add(textField);
		getContentPane().add(downloadButton);
		downloadButton.addActionListener(this);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(WINDOW_SIZE_WIDTH, WINDOW_SIZE_HEIGHT);
		setVisible(true);
	}
	public static void main(String[] args) {
		new DownloadYouTubeWindow();
	}

	public void actionPerformed(ActionEvent e) {
		if(e.getSource() == downloadButton) {
			downloadYouTube(textField.getText());
			
		}
		
	}
	public void downloadYouTube(String Url) {
		/*try {
            String path = "/Users/ryo/Movies/YouTube";
            VGet v = new VGet(new URL(Url), new File(path));
            v.download();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }*/
		HttpURLConnection.setFollowRedirects(true);
		String video_id;
	    System.out.println(Url);
	    String[] list = Url.split("=");
	    video_id = list[1];
	    System.out.println(video_id);
	     try {
			System.out.println(getURL(video_id));
		} catch (Exception e) {
			// TODO 自動生成された catch ブロック
			e.printStackTrace();
		}
	
	}
	
	private static String getURL(String video_id) throws Exception {
	 
	    URL url = new URL("http://youtube.com/watch?v=" + video_id);
	 
	    URLConnection con = url.openConnection();
	    con.connect();
	 
	    // HTMLを取得して動画に対応するt値を取得
	    String t = null;
	    {
	      InputStream is = con.getInputStream();
	      InputStreamReader isr = new InputStreamReader(is, "UTF-8");
	      BufferedReader br = new BufferedReader(isr);
	 
	      // 最小一致は .+?
	      Pattern pattern = Pattern.compile(".*&t=(.+?)&.*");
	      String line;
	      while((line = br.readLine()) != null){
	         Matcher m = pattern.matcher(line);
	         if(m.matches()){
	           t = m.group(1);
	           break;
	         }
	      }
	    }
	 
	    String u ="http://www.youtube.com/get_video?" +
	    	      "video_id=" + video_id + "&t=" + t;
	 
	    return u;
	  }
	 
}
