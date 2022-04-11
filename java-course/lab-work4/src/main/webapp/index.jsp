<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
<%@ taglib uri="WEB-INF/mytag.tld" prefix="tl" %>
<%@ taglib tagdir="/WEB-INF/tags" prefix="td" %>
<!DOCTYPE html>
<html>
<head>
  <title>JSP - Hello World</title>
</head>
<body>
  <h1> Hello World!</h1>

  <tl:mytag>
    Very important message !!!
  </tl:mytag>

  <td:mytag>
    Very important message 2 !!!
  </td:mytag>

</body>
</html>