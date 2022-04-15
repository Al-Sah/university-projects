<jsp:useBean id="result" scope="request" class="com.alsah.labwork3.calculator.CalculationResult"/>
<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>

<jsp:include page="head.jsp" />
<main role="main">

  <div class="container">
    <header class="d-flex justify-content-center py-3">
      <nav class="navbar navbar-light" >
        <ul class="nav nav-pills">
          <li class="nav-item"><a href="${pageContext.request.contextPath}/" class="nav-link active" aria-current="page">Home</a></li>
          </ul>
      </nav>
    </header>


    <div class="row">
      <div class="col-md-8">
        <h1> ${requestScope.message}</h1>

        <div>
          <% if ("POST".equalsIgnoreCase(request.getMethod())) { %>
            <p> ${result.number1} ${result.operation} ${result.number2} = ${result.result}</p>
          <% } %>

        </div>

        <form action="${pageContext.request.contextPath}/" method="post" class="shadow-sm p-3 mb-5 bg-body rounded">

          <div class="mb-3 row">
            <label for="number1" class="form-label"> Enter first number </label>
            <div class="col-sm-10">
              <input type="number" minlength="1" name="number1" class="form-control" id="number1" required>
            </div>
          </div>
          <div class="mb-3 row">
            <label for="number2" class="form-label"> Enter second number </label>
            <div class="col-sm-10">
              <input type="number" minlength="1" name="number2" class="form-control" id="number2" required>
            </div>
          </div>

          <div class="form-check ">
            <input class="form-check-input" type="radio" name="operation" id="multiply" value="multiply" checked>
            <label class="form-check-label" for="multiply"> multiply (*) </label>
          </div>
          <div class="form-check">
            <input class="form-check-input" type="radio" name="operation" id="divide" value="divide">
            <label class="form-check-label" for="divide"> divide (/) </label>
          </div>
          <div class="form-check">
            <input class="form-check-input" type="radio" name="operation" id="add" value="add">
            <label class="form-check-label" for="add"> add (+) </label>
          </div>
          <div class="form-check">
            <input class="form-check-input" type="radio" name="operation" id="subtract" value="subtract">
            <label class="form-check-label" for="subtract"> subtract (-) </label>
          </div>
          <div class="p-2 mt-1">
            <button type="submit" class="btn btn-success"> Calculate</button>
          </div>
        </form>

      </div>
    </div>


    <div class="container">
      <footer class="py-3 my-4">
        <ul class="nav justify-content-center border-bottom pb-3 mb-3">
          <li class="nav-item"><a href="${pageContext.request.contextPath}/" class="nav-link active" aria-current="page">Home</a></li>
        </ul>
        <p class="text-center text-muted"> 2022 | University lab-work :)</p>
      </footer>
    </div>
  </div>
</main>
<jsp:include page="tail.jsp"/>
