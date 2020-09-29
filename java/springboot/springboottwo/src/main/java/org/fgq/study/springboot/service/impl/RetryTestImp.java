package org.fgq.study.springboot.service.impl;

import org.fgq.study.springboot.service.RetryTest;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.remoting.RemoteAccessException;
import org.springframework.retry.annotation.Backoff;
import org.springframework.retry.annotation.Recover;
import org.springframework.retry.annotation.Retryable;
import org.springframework.stereotype.Service;

import java.time.LocalTime;

/**
 * Created by fengguoqiang 2020/8/14
 */
@Service
public class RetryTestImp implements RetryTest {
    private final static Logger logger = LoggerFactory.getLogger(RetryTestImp.class);

    @Retryable(value = {RemoteAccessException.class}, maxAttempts = 3, backoff = @Backoff(delay = 1000l, multiplier = 2))
    public void call() throws Exception {
        logger.info(LocalTime.now() + " do something...");
        System.out.println("调用其他系统失败");
        throw new RemoteAccessException("调用其他系统失败");
    }

    @Recover
    public void recover(RemoteAccessException e) {
        System.out.println("失败");
        logger.error(e.getMessage());
    }
}
