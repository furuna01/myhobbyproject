package scrapewebsite;

import java.util.ArrayList;

public class ToolForScrape {

	public ArrayList<String> getTargetImage(String htmlText) {
		ArrayList<String> targetListPath = new ArrayList<String>();
		String sourceHtml = copyString(htmlText);
		
		//a href= のリンクの文字列のリストtargetListPathにとってくる
		getHrefLink(sourceHtml, targetListPath);
		return targetListPath;
	}
	
	public void getHrefLink(String htmlText, ArrayList<String> targetList) {
		int begin = -1;
		while(htmlText.contains("a href=") || htmlText.contains("a href = ")) {
			if(htmlText.contains("a href=")) {
				begin = htmlText.indexOf("a href=");
				htmlText = htmlText.substring(begin);
			}else if (htmlText.contains("a href = ")) {
				begin = htmlText.indexOf("a href = ");
				htmlText = htmlText.substring(begin);
			}
			//<a href 以降の"で囲まれた文字列を切り取る
			htmlText = htmlText.substring(htmlText.indexOf("\"") + 1);
			String subText = htmlText.substring(0, htmlText.indexOf("\""));
			targetList.add(subText);
			htmlText = htmlText.substring(htmlText.indexOf("\"") + 1);
			//あとでこれが画像などのファイルを含むパスであるかチェックする
		}
	}
	public String copyString(String sentence) {
		String result_str = "";
		
		for(int i = 0; i < sentence.length(); i ++) {
			result_str += String.valueOf(sentence.charAt(i));
		}
		return result_str;
	}
}