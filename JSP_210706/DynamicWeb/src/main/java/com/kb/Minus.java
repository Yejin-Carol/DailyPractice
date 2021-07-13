package com.kb;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.GenericServlet;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.annotation.WebServlet;

/**
 * Servlet implementation class Minus
 */
@WebServlet("/Minus")
public class Minus extends GenericServlet {

	public void service(ServletRequest request, ServletResponse response) throws ServletException, IOException {
		long number1 = Long.parseLong(request.getParameter("number1"));
		long number2 = Long.parseLong(request.getParameter("number2"));
	
		PrintWriter out = response.getWriter();
		out.println("number1 - number2 = " + (number1 - number2));
	}

}
