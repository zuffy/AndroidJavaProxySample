package com.test.callbacktest;

/**
 * Created by Zuffy.Ma on 2016/12/28.
 *
 */

public class UnityInterfaceManager {

    private static UnityInterfaceManager _manager;

    public static UnityInterfaceManager getInstance() {
        if(_manager == null) {
            synchronized (UnityInterfaceManager.class) {
                if(_manager == null) {
                    _manager = new UnityInterfaceManager();
                }
            }
        }
        return  _manager;
    }

    IUnityCallback callback;
    public String hello(IUnityCallback call) {
        callback = call;
        dosomething();
        return "hello world.";
    }


    private void dosomething() {
        new Thread(new Runnable() {
            @Override
            public void run() {
                try {
                    Thread.sleep(2000);
                    if(callback != null) {
                        callback.onSuccess("hello world success!");
                    }
                    Thread.sleep(2000);
                    if(callback != null) {
                        callback.onError(-1, "hello world error!");
                    }
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }finally {
                    callback = null;
                }
            }
        }).start();
    }

}
