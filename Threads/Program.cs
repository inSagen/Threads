// See https://aka.ms/new-console-template for more information
using System;
using System.Threading;
using System.Threading.Tasks;

public class Foo {
    private object _lock = new object();
    int ochered = 1;

    public Foo() {}

    public void First(Action printFirst) {
        lock(_lock){
            // printFirst() outputs "first". Do not change or remove this line.
            printFirst();
            ochered++;
            Monitor.PulseAll(_lock);
        }
    }

    
    public void Second(Action printSecond) {
        lock(_lock){
            while(ochered !=2){
                Monitor.Wait(_lock);
            }
            // printSecond() outputs "second". Do not change or remove this line.
            printSecond();
            ochered++;
            Monitor.PulseAll(_lock);
        }
    }

    public void Third(Action printThird) {
        lock(_lock){
            while(ochered !=3){
                Monitor.Wait(_lock);
            }
            // printThird() outputs "third". Do not change or remove this line.
            printThird();
        }
    }
}