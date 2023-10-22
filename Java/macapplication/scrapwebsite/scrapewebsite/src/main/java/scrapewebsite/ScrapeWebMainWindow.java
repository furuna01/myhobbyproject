package scrapewebsite;

import java.util.ArrayList;

public class ScrapeWebMainWindow {

	public static void main(String[] args) {
		//JunitでM2チップのMacで動かないため仕方なくmain関数で便宜的にテストコードを書いている
		if(test()) {
			System.out.println("テスト成功！");
		}else {
			System.out.println("テスト失敗！");
		}
	}
	private static boolean test() {
		ToolForScrape scrape = new ToolForScrape();
		ArrayList<String> targetLink = new ArrayList<String>();
		ArrayList<String> expectedLink = new ArrayList<String>();
		expectedLink.add("this_is_link");
		expectedLink.add("this is secondLink");
		String htmlText = "abcd <a href=\"this_is_link\"> ddd <a href = \"this is secondlink\" dd";
		
		
		scrape.getHrefLink(htmlText, targetLink);
		if(targetLink.size() != expectedLink.size()) {
			return false;
		}
		for(int i = 0; i < expectedLink.size(); i ++) {
			if(targetLink.get(i) != expectedLink.get(i)) {
				return false;
			}
		}
		return true;
	}

}
