package net.fgq.study.jsonschema;

import org.everit.json.schema.Schema;
import org.everit.json.schema.loader.SchemaLoader;
import org.json.JSONObject;
import org.json.JSONTokener;

import java.io.InputStream;

/**
 * Created by fengguoqiang 2020/12/3
 */
public class JsonSchemaOne {

    public static void main(String[] args) throws Exception {

        try (InputStream inputStream = JsonSchemaOne.class.getResourceAsStream("/jsonschema/schema.json")) {

            try (InputStream inputStream2 = JsonSchemaOne.class.getResourceAsStream("/jsonschema/json.json")) {

                JSONObject schemaObject = new JSONObject(new JSONTokener(inputStream));
                Schema schema = SchemaLoader.load(schemaObject);

                JSONObject jsonObject = new JSONObject(new JSONTokener(inputStream2));
                schema.validate(jsonObject);
                System.out.println("success");
            }

        }

    }

}
