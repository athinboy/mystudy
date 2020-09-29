package org.fgq.study.springboot.controller;

import org.apache.commons.lang3.time.DateFormatUtils;
import org.fgq.study.springboot.service.impl.RetryTestImp;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.remoting.RemoteAccessException;
import org.springframework.retry.annotation.Backoff;
import org.springframework.retry.annotation.Recover;
import org.springframework.retry.annotation.Retryable;
import org.springframework.retry.support.RetryTemplate;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import java.time.LocalTime;
import java.util.Date;

/**
 * Created by fengguoqiang 2020/8/14
 */
@RestController()
@RequestMapping("/one")
public class One {

    @Autowired
    private RetryTestImp retryTestImp;
    private Logger logger = LoggerFactory.getLogger(One.class);

    public interface A<T, E extends Throwable> {

        T doWithRetry(String context) throws E;

    }

    public final <T, E extends Throwable> T execute(A<T, E> retryCallback) throws E {
        return retryCallback.doWithRetry("fwefwef");
    }

    @GetMapping(value = "/test1", produces = {"application/json;charset=UTF-8"})
    public String queryMemberSmsTemplateList() throws Throwable {

//        this.execute(s -> {
//            System.out.println(s);
//            return null;
//        });
//
//
//        this.execute(new A<Object, Throwable>() {
//            @Override
//            public Object doWithRetry(String context) throws Throwable {
//                return null;
//            }
//        });

        retryTestImp.call();

        return DateFormatUtils.format(new Date(), "yyyy-MM-dd hh:mm:ss SSS");
    }

}
