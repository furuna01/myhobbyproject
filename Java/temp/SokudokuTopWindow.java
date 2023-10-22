package sokudokusiya;

import javAa.awt.Color;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class SokudokuTopWindow extends JFrame implements ActionListener{
	private final int WINDOW_WIDTH = 800;
	private final int WINDOW_HEIGHT = 600;
	private JPanel panel;
	private static JButton buttonTate;
	private static JButton buttonYoko;
	public SokudokuTopWindow() {
		//Windlwの大きさ
		panel = new JPanel();
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		buttonTate = new JButton("縦");
		buttonTate.setBackground(Color.gray);
		buttonTate.setSize(50, 20);
		buttonTate.addActionListener(this);
		buttonYoko = new JButton("横");
		buttonYoko.setBackground(Color.gray);
		buttonYoko.setSize(50, 20);
		buttonYoko.addActionListener(this);
	    panel.add(buttonTate);
	    panel.add(buttonYoko);
	    panel.setLayout(new FlowLayout());
		setSize(WINDOW_WIDTH, WINDOW_HEIGHT);
		setContentPane(panel);
		setVisible(true);
	}
	public static void main(String[] args) {
		new SokudokuTopWindow();
	}
	@Override
	public void actionPerformed(ActionEvent e) {
		if(e.getSource() == buttonTate) {
			SokudokuSiyaTateWindow form1 = new SokudokuSiyaTateWindow();
			form1.showWindow("速読縦", true);
		}
		if(e.getSource() == buttonYoko) {
			SokudokuSiyaTateWindow form2 = new SokudokuSiyaTateWindow();
			form2.showWindow("速読横", false);
		}
		
	}

}
