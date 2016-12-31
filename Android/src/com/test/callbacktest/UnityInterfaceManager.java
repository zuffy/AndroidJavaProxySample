package com.test.callbacktest;

import android.util.Log;

import org.reactivestreams.Subscriber;

import java.util.concurrent.Callable;
import java.util.concurrent.TimeUnit;

import io.reactivex.Flowable;
import io.reactivex.Observable;
import io.reactivex.ObservableEmitter;
import io.reactivex.ObservableOnSubscribe;
import io.reactivex.ObservableSource;
import io.reactivex.disposables.Disposable;
import io.reactivex.functions.BiFunction;
import io.reactivex.functions.Consumer;
import io.reactivex.functions.Function;

/**
 * Created by Zuffy.Ma on 2016/12/28.
 *
 */

public class UnityInterfaceManager {

    private static final String TAG = "UnityInterfaceManager";
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

    public Disposable hello(final IUnityCallback call) {
        return Observable.defer(new Callable<ObservableSource<String>>() {
                    @Override
                    public ObservableSource<String> call() throws Exception {
                        return dosomething();
                    }
                })
                .map(new Function<String, String>() {
                    @Override
                    public String apply(String integer) throws Exception {
                        return  String.valueOf(integer);
                    }
                })
                .subscribe(new Consumer<String>() {
                    @Override
                    public void accept(String o) throws Exception {
                        Log.d(TAG, "res:" + o);
                        call.onSuccess(o);
                    }
                }, new Consumer<Throwable>() {
                    @Override
                    public void accept(Throwable throwable) throws Exception {
                        call.onError(-1, throwable.getMessage());
                    }
                });
    }

    private Observable dosomething() {
        return Observable.zip(Observable.interval(1, TimeUnit.SECONDS).take(3), Observable.just("hello world 111", "i am java", "test"), new BiFunction() {
            @Override
            public Object apply(Object o, Object o2) throws Exception {
                return o  + " " + o2;
            }
        });
    }

}
