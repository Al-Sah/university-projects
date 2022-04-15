package com.alsah.labwork4;

import javax.servlet.jsp.JspException;
import javax.servlet.jsp.tagext.SimpleTagSupport;
import java.io.IOException;
import java.io.StringWriter;

public class MyTagHandler extends SimpleTagSupport {

    @Override
    public void doTag() throws JspException, IOException {
        StringWriter sw = new StringWriter();
        getJspBody().invoke(sw);
        getJspContext().getOut().println(String.format("<p style=\"color: crimson; size: A3\">%s</p>", sw));
    }
}
