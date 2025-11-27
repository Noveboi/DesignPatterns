package Delegation;

import java.util.Scanner;

public class ProtectedDoor implements Door {

    private DoorPasswordAdapter adapter;
    private PasswordProtector protector;
    private boolean isLocked = false;

    public ProtectedDoor(int code, PasswordProtector protector) {
        this.adapter = new DoorPasswordAdapter();
        this.protector = protector;

        protector.register(code, adapter);
    }

    @Override
    public void lock() {
        if (isLocked){
            System.out.println("Door is already locked!");
        }
        
        isLocked = true;
    }

    @Override
    public void unlock() {
        try (Scanner scanner = new Scanner(System.in)) {
            System.out.println("Enter code: ");
            
            int code = scanner.nextInt();

            if (protector.check(code)) {
                System.out.println("Unlocked!");
                isLocked = false;
            }
        }
    }
}
