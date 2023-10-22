package sokudokusiya;

import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.Graphics;
import java.util.Timer;
import java.util.TimerTask;

import javax.swing.JFrame;
import javax.swing.JPanel;


public class SokudokuSiyaTateWindow extends JPanel {
	
	private int FONT_SIZE;
	private final int WINDOW_WIDTH = 1100;
	private final int WINDOW_HEIGHT = 600;
	private final static int TIME_INTERVAL = 2000;
	private Font number_font = new Font("Arial", Font.PLAIN, FONT_SIZE);
	private int numberOfDisplay = 1;
	private boolean fTate = true;
	//コンストラクタ
	public SokudokuSiyaTateWindow() {
		//Windowの大きさ
		setPreferredSize(new Dimension(WINDOW_WIDTH, WINDOW_HEIGHT));
	}
	public void showWindow(String text, boolean flag) {
		JFrame frame = new JFrame();
		if(!flag) {
			FONT_SIZE = 20;
			fTate = false;
		}else {
			FONT_SIZE = 17;
			fTate = true;
		}
		SokudokuSiyaTateWindow window = new SokudokuSiyaTateWindow();
	    frame.getContentPane().add(window);
		frame.getContentPane().setLayout(new FlowLayout());
        frame.pack();
        frame.setResizable(false);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setVisible(true);
        
        //Graphics graphics = frame.getGraphics();
		//frame.paint(graphics);
        
        Timer timer = new Timer(false);
    	TimerTask task = new TimerTask() {
     
    		@Override
    		public void run() {
    			//8回実行で停止
    			Graphics graphics = frame.getGraphics();
    			frame.paint(graphics);
    			
    		}
    	};
    	timer.scheduleAtFixedRate(task, 0, TIME_INTERVAL);
	}

	public void paint(Graphics g){

		  g.setFont(number_font);
		  
		  if(numberOfDisplay == 14) {
			  numberOfDisplay = 1;
		  }
		  if(fTate) {
			  g.drawString(String.valueOf(numberOfDisplay), (WINDOW_WIDTH / 2) , 
					  (WINDOW_HEIGHT / 2) - FONT_SIZE * numberOfDisplay);
			  g.drawString(String.valueOf(numberOfDisplay), (WINDOW_WIDTH / 2) , 
					  (WINDOW_HEIGHT / 2) + FONT_SIZE * numberOfDisplay);
		  }else {
			  g.drawString(String.valueOf(numberOfDisplay), (WINDOW_WIDTH / 2) - FONT_SIZE * numberOfDisplay,
					  (WINDOW_HEIGHT / 2));
			  g.drawString(String.valueOf(numberOfDisplay), (WINDOW_WIDTH / 2) + FONT_SIZE * numberOfDisplay,
					  (WINDOW_HEIGHT / 2));
		  }
		  
		  try {
			  Thread.sleep(TIME_INTERVAL / 2);
		  }catch(Exception e) {
			  
		  }
		  g.clearRect(0, 0, WINDOW_WIDTH, WINDOW_HEIGHT);
		  numberOfDisplay ++;
	}
}
