package org.fgq.study.datapadding;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

/**
 * @author fenggqc
 * @create 2018-10-24 11:59
 **/


@Configuration
public class SpringConfig {

    //region Getter And Setter
    // endregion

    @Bean
    public InitBean myService() {
        return new InitBean();
    }




}
