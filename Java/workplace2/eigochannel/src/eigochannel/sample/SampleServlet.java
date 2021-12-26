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
		String str = "ABC";
		out.println("<html>");
		out.println("<body>");
		out.println("</body>");
		out.println("<p>" + str + "</p>");
		out.println("<p>暗号化された後</p>");
		LogicEncript encript = new LogicEncript();
		byte[] afterbyte = null;
		try {
			afterbyte = encript.EncripString(str);
		}catch(Exception e) {
			out.println(e.getMessage());
		}
		String newStr = new String(afterbyte);
		out.println(newStr);
		out.println("<p>復号後</p>");
		String afterStr = null;
		try {
			afterStr = encript.DecripByte(afterbyte);
		}catch (Exception e) {
			out.println(e.getMessage());
		}
		out.println("<p>" + afterStr + "</p>");
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
