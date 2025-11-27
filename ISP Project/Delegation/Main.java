package Delegation;

public class Main {
    public static void main(String[] args) {
        PasswordProtector protector = new PasswordProtector();
        ProtectedDoor door = new ProtectedDoor(2525, protector);

        door.lock();
        door.unlock();
    }
}
