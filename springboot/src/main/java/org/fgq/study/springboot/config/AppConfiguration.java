package org.fgq.study.springboot.config;

import org.springframework.context.annotation.Import;
import org.springframework.context.annotation.Configuration;
import org.springframework.stereotype.Component;

/**
 * @author fenggqc
 * @create 2018-12-28 10:39
 **/

@Configuration
@Import({RedisConfiguration.class})
public class AppConfiguration {

    //region Getter And Setter
    // endregion
}
