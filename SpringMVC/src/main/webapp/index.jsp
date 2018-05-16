 <%@ page import="java.util.Date" %>

<%--
  Created by IntelliJ IDEA.
  User: fenggqc
  Date: 2016/3/21
  Time: 10:07
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>fgqfgq22</title>
</head>
<body>


<%--<% response.getWriter().print(java.time.Instant.now().toString());%>--%>
<% response.getWriter().print(String.valueOf(new Date().getTime()));%>


</body>
</html>
