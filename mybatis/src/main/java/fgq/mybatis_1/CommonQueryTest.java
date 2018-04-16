package fgq.mybatis_1;

import java.io.InputStream;
import java.security.Principal;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.dbcp.BasicDataSource;
import org.apache.commons.dbcp.DataSourceConnectionFactory;
import org.apache.ibatis.io.Resources;


import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.ibatis.session.SqlSessionFactoryBuilder;


import org.apache.log4j.LogManager;
import org.apache.log4j.Logger;
import org.fgq.query.mapper.CommonMapper;



/**
 * Created by fenggqc on 2016/12/16.
 */
public class CommonQueryTest {


    public static void main(String[] args) throws Exception {


        //org.apache.ibatis.logging.LogFactory.useLog4J2Logging();

        CommonQueryTest CommonQueryTest = new CommonQueryTest();

        CommonQueryTest.Test();


    }


    private void Test() throws Exception {
        {


            Logger logger = LogManager.getLogger(CommonQueryTest.class);

            logger.error("111111111111111111111111111111111111111111111111111111");


            InputStream is = Resources.getResourceAsStream("mybatis-config.xml");

            SqlSessionFactory sqlSessionFactory = null;
            SqlSessionFactoryBuilder sqlSessionFactoryBuilder = new SqlSessionFactoryBuilder();
            sqlSessionFactory = sqlSessionFactoryBuilder.build(is);
            is.close();
            fgq.mybatis_1.UI ui;
            UI2 ui2=new UI2();
            List<?> result;
            SqlSession sqlSession = null;
            sqlSession = sqlSessionFactory.openSession();

           // ui = sqlSession.selectOne("selectbutton", "buttonAdd");

             UI2Mapper ui2Mapper = sqlSession.getMapper(UI2Mapper.class);
            ui2 = ui2Mapper.SelectOne("\"buttonAdd\" + 2");


            //          CommonMapper<UI2> commonMapper = sqlSession.getMapper(CommonMapper.class);
            //       Object o  = commonMapper.SelectByPrimaryKey(ui2);


            sqlSession.close();


//            ///////////----------------------------------------------------------------------
//
//
//
//            org.apache.commons.dbcp.BasicDataSource dataSource = new BasicDataSource();
//            dataSource.setDriverClassName("com.mysql.jdbc.Driver");
//            dataSource.setUrl("jdbc:mysql://10.0.2.120:3306/test_db");
//            dataSource.setUsername("root");
//            dataSource.setPassword("itstest$");
//            Connection connection;
//
//            org.apache.commons.dbcp.DataSourceConnectionFactory dataSourceConnectionFactory = null;
//
//
//            dataSourceConnectionFactory = new DataSourceConnectionFactory(dataSource);
//            connection = dataSourceConnectionFactory.createConnection();
//
//
//
//                PreparedStatement s = connection.prepareStatement("select e.page_id as 'button_id',e.page_name as 'text_value'\n" +
//                        "  from ui_page e " +
//                        " WHERE e.page_id=?");
//
//                s.setString(1, "buttonAdd" + 1);
//                ResultSet rs = s.executeQuery();
//
//
//                while (rs.next()) {
//
//                    ui = new fgq.mybatis_1.UI();
//                    ui.setButton_id(rs.getString("button_id"));
//                    ui.setText_value(rs.getString("text_value"));
//
//                }
//
//
//
//            connection.close();
//            ///////////----------------------------------------------------------------------


        }
    }
}