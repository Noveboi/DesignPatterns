package Delegation;

public class PasswordProtector {
    
    private int safeNumber;
    private PasswordClient client;

    public void register(int code, PasswordClient client) {
        this.safeNumber = code;
        this.client = client;
    }

    public boolean check(int code) {
        if (this.safeNumber != code) {
            client.alarm();
            return false;
        }

        return true;
    }
}