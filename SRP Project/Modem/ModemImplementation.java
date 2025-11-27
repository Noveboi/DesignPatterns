package Modem;

import java.io.IOException;

public class ModemImplementation implements DataChannel, Connection {

    private String pno = null;

    @Override
    public void dial(String pno) {
        this.pno = pno;
    }

    @Override
    public void hangup() {
        this.pno = null;
    }

    @Override
    public void send(char c) {
        System.out.println(this.pno + c);
    }

    @Override
    public char recv() {
        try {
            return (char)System.in.read();
        } catch (IOException e) {
            e.printStackTrace();
            return '\0';
        }
    }
    
}
