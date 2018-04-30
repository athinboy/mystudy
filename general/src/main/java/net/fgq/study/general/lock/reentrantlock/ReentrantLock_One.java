package net.fgq.study.general.lock.reentrantlock;

import java.util.concurrent.locks.Condition;
import java.util.concurrent.locks.ReentrantLock;

public class ReentrantLock_One {

    //region Getter And Setter
    // endregion


    public static void main(String[] args) {

        ReentrantLock reentrantLock = new ReentrantLock(true);

        Condition condition = reentrantLock.newCondition();


    }

}
