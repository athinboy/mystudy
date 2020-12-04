package net.fgq.study.jsonschema;

import com.github.fge.jsonschema.main.JsonSchemaFactory;
import org.everit.json.schema.Schema;
import org.everit.json.schema.loader.SchemaLoader;
import org.json.JSONObject;
import org.json.JSONTokener;

import java.io.InputStream;

/**
 * Created by fengguoqiang 2020/12/3
 *
 * https://blog.csdn.net/weixin_33670786/article/details/90366645
 */
public class JsonSchemaTwo {

    public static void main(String[] args) throws Exception {

        try (InputStream inputStream = JsonSchemaTwo.class.getResourceAsStream("/jsonschema/schema.json")) {

            try (InputStream inputStream2 = JsonSchemaTwo.class.getResourceAsStream("/jsonschema/json.json")) {

                JSONObject schemaObject = new JSONObject(new JSONTokener(inputStream));
                Schema schema = SchemaLoader.load(schemaObject);

                JSONObject jsonObject = new JSONObject(new JSONTokener(inputStream2));
                schema.validate(jsonObject);
                System.out.println("success");


            }

        }

    }

}
