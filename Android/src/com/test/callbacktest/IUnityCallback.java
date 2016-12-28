package com.test.callbacktest;

/**
 * Created by Zuffy.Ma on 2016/12/28.
 *
 */

public interface IUnityCallback {
    void onSuccess(String result);

    void onError(int errorcode, String msg);
}
