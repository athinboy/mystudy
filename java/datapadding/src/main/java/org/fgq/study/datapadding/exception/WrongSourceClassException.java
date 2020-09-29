package org.fgq.study.datapadding.exception;

/**
 * @author fenggqc
 * @create 2018-10-29 15:20
 **/
public class WrongSourceClassException extends DataPaddingException {

    //region Getter And Setter
    // endregion

    public WrongSourceClassException(String message, Throwable cause) {
        super(message, cause);
    }

    public WrongSourceClassException(String message) {
        super(message);
    }
}
