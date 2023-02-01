<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%!
public String repeat(String msg, int cnt) {
	String result = "";
	for(int i = 0; i < cnt; i ++) {
		result += msg;
	}
	return result;
}
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Sample JSP</title>
</head>
<body>
<h1>Hello World!</h1>
<% out.println(repeat("5回繰り返します<br>", 5)); %>
</body>
</html>