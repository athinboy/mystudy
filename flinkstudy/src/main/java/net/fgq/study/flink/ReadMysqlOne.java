package net.fgq.study.flink;

import org.apache.flink.api.common.typeinfo.BasicTypeInfo;
import org.apache.flink.api.java.io.jdbc.JDBCInputFormat;
import org.apache.flink.api.java.typeutils.RowTypeInfo;
import org.apache.flink.streaming.api.datastream.DataStreamSource;
import org.apache.flink.streaming.api.environment.StreamExecutionEnvironment;
import org.apache.flink.types.Row;

/**
 * @author fenggqc
 * @create 2018-11-28 18:43
 **/

public class ReadMysqlOne {

    //region Getter And Setter
    // endregion

    public static void main(String[] args) throws Exception {

        // get the execution environment
        final StreamExecutionEnvironment env = StreamExecutionEnvironment.getExecutionEnvironment();

        JDBCInputFormat jdbcInputFormat = JDBCInputFormat.buildJDBCInputFormat()
                .setDBUrl("jdbc:mysql://" + CommonConfig.DBIP + ":" + CommonConfig.DBPort + "/study")
                .setDrivername("com.mysql.jdbc.Driver")
                .setUsername("root")
                .setPassword("123")
                .setQuery("select room_id,room_name,room_cdesc from ba_room")
                .setRowTypeInfo(new RowTypeInfo(
                        BasicTypeInfo.STRING_TYPE_INFO,
                        BasicTypeInfo.STRING_TYPE_INFO,
                        BasicTypeInfo.STRING_TYPE_INFO))
                .finish();
        DataStreamSource<Row> rowDataStreamSource = env.createInput(jdbcInputFormat);
        rowDataStreamSource.windowAll()
        rowDataStreamSource.print();

    }
}
