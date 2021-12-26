package eigochannel.sample;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import eigochannel.util.LogicEncript;

/**
 * Servlet implementation class SampleServlet
 */
@WebServlet("/SampleServlet")
public class SampleServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;

    /**
     * @see HttpServlet#HttpServlet()
     */
    public SampleServlet() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stubs
		PrintWriter out = response.getWriter();
		out.println("<html>");
		out.println("<body>");
		out.println("</body>");
		String dataBaseName = "eigochannel";
		String userName = "yonezawa";
		String password = "suminftyj=1";
		out.println("<p>" + dataBaseName + "</p>");
		out.println("<p>" + userName + "</p>");
		out.println("<p>" + password + "</p>");
		out.println("<p>After Enripting</p>");
		LogicEncript encript = new LogicEncript();
		byte[] afterbyte1 = null;
		byte[] afterbyte2 = null;
		byte[] afterbyte3 = null;
		try {
			afterbyte1 = encript.EncripString(dataBaseName);
			afterbyte2 = encript.EncripString(userName);
			afterbyte3 = encript.EncripString(password);

		}catch(Exception e) {
			out.println(e.getMessage());
		}
		String afterstr1 = new String(afterbyte1);
		String afterstr2 = new String(afterbyte2);
		String afterstr3 = new String(afterbyte3);
		out.println(afterstr1);
		out.println(afterstr2);
		out.println(afterstr3);
		out.println("<p>AfterDeripting</p>");
		try {
			dataBaseName = encript.DecripByte(afterbyte1);
			userName = encript.DecripByte(afterbyte2);
			password = encript.DecripByte(afterbyte3);
		}catch (Exception e) {
			out.println(e.getMessage());
		}
		out.println("<p>" + dataBaseName + "</p>");
		out.println("<p>" + userName + "</p>");
		out.println("<p>" + password + "</p>");
		out.println("</html>");
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
