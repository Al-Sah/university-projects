package com.alsah.labwork3;

import com.alsah.labwork3.calculator.CalculationResult;
import com.alsah.labwork3.calculator.Calculator;
import com.alsah.labwork3.calculator.InvalidCalculatorArgument;

import java.io.*;
import javax.servlet.ServletException;
import javax.servlet.http.*;
import javax.servlet.annotation.*;

@WebServlet("/")
public class MainServlet extends HttpServlet {

    @Override
    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        request.setAttribute("message",  "Hello user !");
        request.getRequestDispatcher("home.jsp").forward(request, response);
    }


    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

        try {
            CalculationResult result = Calculator.execute(
                    request.getParameter("number1"),
                    request.getParameter("number2"),
                    request.getParameter("operation"));
           request.setAttribute("message",  "Result: " + result.getResult());
           request.setAttribute("result",  result);

        } catch (InvalidCalculatorArgument e) {
            request.setAttribute("message",  "Failed to calculate: " + e.getMessage());
        }
        request.getRequestDispatcher("home.jsp").forward(request, response);
    }

}