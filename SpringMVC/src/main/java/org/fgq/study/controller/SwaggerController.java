package org.fgq.study.controller;

import io.swagger.annotations.ApiResponse;
import io.swagger.annotations.ApiResponses;
import io.swagger.annotations.Example;
import io.swagger.annotations.ExampleProperty;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import springfox.documentation.swagger2.annotations.EnableSwagger2;

/**
 * @author fenggqc
 * @create 2019-01-31 16:27
 **/

//http://springfox.github.io/springfox/docs/current/
//
//@EnableSwagger2
//@Controller()
//@RequestMapping("/mvc/swagger")
public class SwaggerController extends SwaggerControllerBase {

    //region Getter And Setter
    // endregion

    @ApiResponses(
            @ApiResponse(code = 200, message = "OK",
                    examples = @Example(@ExampleProperty(mediaType = "application/json",
                            value = "{\"gnarf\": \"dragons\"}"))))
//    @PostMapping("/conversion/controller")
    public @ResponseBody
    Baz convert(@RequestBody Baz baz) {
        return baz;
    }

    public static class Baz {
        public String getGnarf() {
            return gnarf;
        }

        public void setGnarf(String gnarf) {
            this.gnarf = gnarf;
        }

        private String gnarf;
    }

    public static class Foo {
        private String bar;
        private boolean foo = false;
        private int count = 3;

        public Foo() {

        }

        public Foo(String bar) {
            this.bar = bar;
        }

        public String getBar() {
            return bar;
        }

        public void setBar(String bar) {
            this.bar = bar;
        }

        public boolean isFoo() {
            return foo;
        }

        public void setFoo(boolean foo) {
            this.foo = foo;
        }

        public int getCount() {
            return count;
        }

        public void setCount(int count) {
            this.count = count;
        }
    }

}
