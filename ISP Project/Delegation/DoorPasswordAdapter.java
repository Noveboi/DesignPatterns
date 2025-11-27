package Delegation;

public class DoorPasswordAdapter implements PasswordClient {
    @Override
    public void alarm() {
        System.out.println("Intruder ALERT!!!");
    }
}
