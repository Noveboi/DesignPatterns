# Measuring LCOM (Lack of Cohesion between Methods)

## Shapes

### Shape.java (initial)

- Field Count: 5
- Method Count: 4
- `draw` references **5** fields
- `paint` references **1** field
- `getXLowerRightCorner` references **1** field
- `getYLowerRightCorner` references **1** field

$$ LCOM = 1 - \frac{5+1+1+1}{5 \cdot 4} = 1 - \frac{8}{20} = 0.6 $$

### Shape.java (final)

- Field Count: 5
- Method Count: 2
- `draw` references **5** fields
- `paint` references **1** field

$$ LCOM = 1 - \frac{5 + 1}{2 \cdot 5} = 1 - \frac{6}{10} = 0.4 $$

### GeometricShape.java

- Field Count: 2
- Method Count: 2
- `getXLowerRightCorner` references 1 field
- `getYLowerRightCorner` references 1 field

$$ LCOM = 1 - \frac{1 + 1}{2 \cdot 2} = 1 - \frac{2}{4} = 0.5 $$

## Modem

### ModemImplementation.java

- Field Count: 1
- Method Count: 4
- `dial` references 1 field
- `hangup` references 1 field
- `send` references 1 field
- `recv` references 0 fields

$$ LCOM = 1 - \frac{1 + 1 + 1 + 0}{4 \cdot 1} = 1 - \frac{3}{4} = 0.25 $$
