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
        <h1> Message: ${requestScope.message}</h1>
      </div>
    </div>


    <div class="container">
      <footer class="py-3 my-4">
        <ul class="nav justify-content-center border-bottom pb-3 mb-3">
          <li class="nav-item"><a href="${pageContext.request.contextPath}/" class="nav-link active" aria-current="page">Home</a></li>
        </ul>
        <p class="text-center text-muted"> 2022; University al-sah :)</p>
      </footer>
    </div>
  </div>
</main>
<jsp:include page="tail.jsp"/>
