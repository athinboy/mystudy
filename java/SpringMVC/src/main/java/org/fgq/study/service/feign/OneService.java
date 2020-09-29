package org.fgq.study.service.feign;


import feign.*;


import java.io.IOException;
import java.util.Map;

public interface OneService {


    @RequestLine("GET /mvc/feigh/hello/{name}")
    String HelloName(@Param("name") String name);


    @Body("myname:{name}")
    @Headers("Cache-Control: max-age=640000,Myname:{name}")
    @RequestLine("POST /mvc/feigh/all/{name}")
    FeighResult All(@Param("name") String name, @HeaderMap Map headers, @QueryMap Map querymap) throws IOException;


//    @GET
//    @Path("/")
//    void JAXRS();


}
