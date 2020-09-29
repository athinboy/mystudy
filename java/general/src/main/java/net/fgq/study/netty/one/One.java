package net.fgq.study.netty.one;

public class One {

    //region Getter And Setter
    // endregion


    public static void main(String[] args) throws Exception {



        int port = 5000;


        final String host = "127.0.0.1";

        Thread serverthread=new Thread(new Runnable() {
            @Override
            public void run() {
                try {
                    new Server(port).start();
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        });


        Thread clientthread=new Thread(new Runnable() {
            @Override
            public void run() {
                try {
                    new Client(host, port).start();
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        });


        serverthread.start();
        clientthread.start();




    }


}
