use std::fs;

pub fn execute() -> () {
    let measures = fs::read_to_string("src/day01.txt").expect("Unable to read file");
    let mut ocurrence: u32 = 0;
    let lines:Vec<u32> = measures.lines().map(|x| x.parse::<u32>().unwrap()).collect();
    let mut last_read: u32 = lines[0];
    for line in lines.clone() {
        if line > last_read{
            ocurrence += 1;
        }
        last_read = line;
    }
    println!("Day 01.01 : {}", ocurrence);

    ocurrence = 0;
    let mut last_total = lines[0] + lines[1] + lines[2];
    for line in lines.windows(3) {
        let sub_total = line.iter().sum();
        if sub_total > last_total {
            ocurrence += 1;
        }
        last_total = sub_total;
    }
    println!("Day 01.02 : {}", ocurrence);
}
