package org.fgq.study.datapadding.exception;

/**
 * @author fenggqc
 * @create 2018-10-29 16:21
 **/


public class WrongAnnotationException extends  DataPaddingException   {

    //region Getter And Setter
    // endregion

    public WrongAnnotationException(String message, Throwable cause) {
        super(message, cause);
    }

    public WrongAnnotationException(String message) {
        super(message);
    }


}
