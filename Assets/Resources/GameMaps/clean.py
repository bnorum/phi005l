import re

def round_to_nearest_05(value):
    return round(value * 20) / 20.0

def process_line(line):
    # Find all decimal numbers in the line
    numbers = re.findall(r"\d+\.\d+", line)
    for number in numbers:
        rounded_number = round_to_nearest_05(float(number))
        line = line.replace(number, f"{rounded_number:.2f}")
    return line

def process_file(input_filename, output_filename):
    with open(input_filename, 'r') as file:
        lines = file.readlines()
    
    with open(output_filename, 'w') as file:
        for line in lines:
            processed_line = process_line(line)
            file.write(processed_line)

# Replace 'input.txt' and 'output.txt' with your actual file names
input_filename = 'ctrl2.txt'
output_filename = 'output.txt'
process_file(input_filename, output_filename)