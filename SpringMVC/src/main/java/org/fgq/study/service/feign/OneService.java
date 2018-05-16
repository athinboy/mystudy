package org.fgq.study.service.feign;


import feign.Param;
import feign.RequestLine;

public interface OneService {


    @RequestLine("GET /mvc/feigh/hello/{name}")
    String HelloName(@Param("name") String name);


}
