package fgq.mybatis_1;

import java.io.InputStream;
import java.security.Principal;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;
import java.sql.*;


import org.apache.commons.dbcp.BasicDataSource;
import org.apache.commons.dbcp.DataSourceConnectionFactory;
import org.apache.commons.lang3.time.StopWatch;
import org.apache.ibatis.io.Resources;

import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.ibatis.session.SqlSessionFactoryBuilder;

import org.apache.ibatis.transaction.TransactionFactory;
import org.apache.ibatis.transaction.jdbc.JdbcTransactionFactory;

import javax.sql.DataSource;

/**
 * Created by fenggqc on 2016/3/2.
 */
public class PerformanceTest {


    public class Record {

        public int Times;

        public long OpenSessionEveryTime_XMLMapper;
        public long OpenSessionOneTime_XMLMapper;
        public long OpenSessionOneTime_AnnotionMapper;
        public long OpenSessionEveryTime_AnnotionMapper;
        public long JDBCOneTime;
        public long JDBCEveryTime;
        public long BDCPOneTime;


    }


    public static void main(String[] args) throws Exception {
        PerformanceTest performanceTest = new PerformanceTest();
        performanceTest.Test();
    }

    private void Test() throws Exception {
        {


          //org.apache.ibatis.logging.LogFactory.useLog4J2Logging();
            //             org.apache.ibatis.logging.LogFactory.useJdkLogging();



            InputStream is = Resources.getResourceAsStream("mybatis-config.xml");

            SqlSessionFactory sqlSessionFactory = null;
            SqlSessionFactoryBuilder sqlSessionFactoryBuilder = new SqlSessionFactoryBuilder();
            sqlSessionFactory = sqlSessionFactoryBuilder.build(is);

            is.close();
            StopWatch sw1 = new StopWatch();


            fgq.mybatis_1.UI ui;
            UI2 ui2;

            List<?> result;

            SqlSession sqlSession = null;


            //region 为了公平，SessionFactory预先加载
            sqlSession = sqlSessionFactory.openSession();
            ui = sqlSession.selectOne("selectbutton", "buttonAdd");
            UI2Mapper ui2Mapper = sqlSession.getMapper(UI2Mapper.class);
            sqlSession.close();
            //endregion


            Integer times = 10;
            ArrayList<Integer> AllTime = new ArrayList<Integer>();
            ArrayList<Record> records = new ArrayList<Record>();
            Record record;

            AllTime.add(1);
            AllTime.add(2);
            AllTime.add(10);
            AllTime.add(100);
            AllTime.add(200);
            AllTime.add(1000);


            for (int ii = 0; ii < AllTime.size(); ii++) {

                times = AllTime.get(ii);
                record = new Record();
                records.add(record);
                record.Times = times;


///////////////////////////////////////////////

                sw1.start();
                for (Integer i = 0; i < times; i++) {
                    sqlSession = sqlSessionFactory.openSession();
                    ui = sqlSession.selectOne("selectbutton", "buttonAdd" + i);
                    sqlSession.close();
                }
                record.OpenSessionEveryTime_XMLMapper = sw1.getTime();
                sw1.stop();
                sw1.reset();

//////////////////////////////////////////
                sw1.start();
                sqlSession = sqlSessionFactory.openSession();
                for (Integer i = 0; i < times; i++) {

                    ui = sqlSession.selectOne("selectbutton", "buttonAdd" + i);

                }
                sqlSession.close();

                record.OpenSessionOneTime_XMLMapper = sw1.getTime();
                sw1.stop();
                sw1.reset();

//////////////////////////////////////////

                sw1.start();
                sqlSession = sqlSessionFactory.openSession();
                ui2Mapper = sqlSession.getMapper(UI2Mapper.class);

                for (Integer i = 0; i < times; i++) {
                    ui2 = ui2Mapper.SelectOne("buttonAdd" + i);
                }
                sqlSession.close();
                //System.out.println("OpenSessionOneTime_AnnotionMapper:" + sw1.getTime());
                record.OpenSessionOneTime_AnnotionMapper = sw1.getTime();
                sw1.stop();
                sw1.reset();
//////////////////////////////////////////

                sw1.start();

                for (Integer i = 0; i < times; i++) {
                    sqlSession = sqlSessionFactory.openSession();
                    ui2Mapper = sqlSession.getMapper(UI2Mapper.class);
                    ui2 = ui2Mapper.SelectOne("buttonAdd" + i);
                    sqlSession.close();
                }

                //System.out.println("OpenSessionEveryTime_AnnotionMapper:" + sw1.getTime());
                record.OpenSessionEveryTime_AnnotionMapper = sw1.getTime();
                sw1.stop();
                sw1.reset();
//////////////////////////////////////////


                // 驱动程序名
                String driver = "com.mysql.jdbc.Driver";
                String uri = "jdbc:mysql://10.0.2.120:3306/test_db";


                Properties p = new Properties();

                p.setProperty("username", "root");
                p.setProperty("password", "itstest$");

                Connection connection;


                sw1.reset();
                sw1.start();
                connection = DriverManager.getConnection(uri, "root", "itstest$");
                for (Integer i = 0; i < times; i++) {

                    PreparedStatement s = connection.prepareStatement(" select e.page_id as 'button_id',e.page_name as 'text_value'\n" +
                            "        from ui_page e\n" +
                            "        WHERE e.page_id=?");

                    s.setString(1, "buttonAdd" + i);
                    ResultSet rs = s.executeQuery();


                    while (rs.next()) {

                ui = new fgq.mybatis_1.UI();
                ui.setButton_id(rs.getString("button_id"));
                ui.setText_value(rs.getString("text_value"));

                    }

                }
                connection.close();

                record.JDBCOneTime = sw1.getTime();
                sw1.stop();
                sw1.reset();


//////////////////////////////////////////////////////////////////


                sw1.start();

                for (Integer i = 0; i < times; i++) {
                    connection = DriverManager.getConnection(uri, "root", "itstest$");

                    PreparedStatement s = connection.prepareStatement("select e.page_id as 'button_id',e.page_name as 'text_value'\n" +
                            "   from ui_page e " +
                            "    WHERE e.page_id=?");

                    s.setString(1, "buttonAdd" + i);

                    ResultSet rs = s.executeQuery();


                    while (rs.next()) {

                ui = new fgq.mybatis_1.UI();
                ui.setButton_id(rs.getString("button_id"));
                ui.setText_value(rs.getString("text_value"));

                    }
                    connection.close();
                }



                record.JDBCEveryTime = sw1.getTime();
                sw1.stop();
                sw1.reset();


//////////////////////////////////////////////////////////////////


                org.apache.commons.dbcp.BasicDataSource dataSource = new BasicDataSource();
                dataSource.setDriverClassName("com.mysql.jdbc.Driver");
                dataSource.setUrl("jdbc:mysql://10.0.2.120:3306/test_db");
                dataSource.setUsername("root");
                dataSource.setPassword("itstest$");


                org.apache.commons.dbcp.DataSourceConnectionFactory dataSourceConnectionFactory = null;


                dataSourceConnectionFactory = new DataSourceConnectionFactory(dataSource);
                connection = dataSourceConnectionFactory.createConnection();

                sw1.start();
                for (Integer i = 0; i < times; i++) {

                    PreparedStatement s = connection.prepareStatement("select e.page_id as 'button_id',e.page_name as 'text_value'\n" +
                            "  from ui_page e " +
                            " WHERE e.page_id=?");

                    s.setString(1, "buttonAdd" + i);
                    ResultSet rs = s.executeQuery();


                    while (rs.next()) {

                        ui = new fgq.mybatis_1.UI();
                        ui.setButton_id(rs.getString("button_id"));
                        ui.setText_value(rs.getString("text_value"));

                    }

                }

                connection.close();

                record.BDCPOneTime = sw1.getTime();

                sw1.stop();
                sw1.reset();


            }

            System.out.println(String.format("%s %s %s %s %s %s %s %s", "Times", "BDCPOneTime", "JDBCEveryTime", "JDBCOneTime", "OpenSessionEveryTime_AnnotionMapper", "OpenSessionEveryTime_XMLMapper"
                    , "OpenSessionOneTime_AnnotionMapper", "OpenSessionOneTime_XMLMapper"
            ));

            for (int i = 0; i < records.size(); i++) {
                record = records.get(i);


                System.out.println(String.format("%d %d %d %d %d %d %d %d"
                        , record.Times, record.BDCPOneTime, record.JDBCEveryTime, record.JDBCOneTime, record.OpenSessionEveryTime_AnnotionMapper, record.OpenSessionEveryTime_XMLMapper
                        , record.OpenSessionOneTime_AnnotionMapper, record.OpenSessionOneTime_XMLMapper
                ));

            }

        }


    }
}