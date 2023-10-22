package scrapewebsite;

import static org.junit.jupiter.api.Assertions.*;

import java.util.ArrayList;

import org.junit.jupiter.api.Test;

public class ToolForScrapeTest {
	
	@Test
	  void testGetHrefLink() {
	    ToolForScrape scrape = new ToolForScrape();
	    ArrayList<String> targetLink = new ArrayList<String>();
	    
	    String htmlText = "abcd <a href=\"this_is_link\"> ddd <a href = \"this is secondlink\" dd";
	    scrape.getHrefLink(htmlText, targetLink);
	    
	    for(String str : targetLink) {
	    	System.out.println("target : " + str);
	    }
	    ArrayList<String> expectedList = new ArrayList<String>();
	    expectedList.add("this_is_link");
	    expectedList.add("this is secondlink");
	    
	    for(String str : expectedList) {
	    	System.out.println("expected : " + str);
	    }
	    
	    assertEquals(expectedList.size(), targetLink.size());
	    
	    for(int i = 0; i < expectedList.size(); i ++) {
	    	assertEquals(expectedList.get(i), targetLink.get(i));
	    }
	  }

}
