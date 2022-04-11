package com.alsah.labwork4;

import javax.servlet.jsp.JspException;
import javax.servlet.jsp.tagext.BodyTagSupport;

public class MyTagHandler extends BodyTagSupport {

    @Override
    public int doStartTag() throws JspException {
        return SKIP_BODY;
    }

}
