use std::fs;

pub fn execute() -> () {
    let measures = fs::read_to_string("src/day02.txt").expect("Unable to read file");
    let mut depth: i32 = 0;
    let mut aim: i32 = 0;
    let mut horizon: i32 = 0;
    for line in measures.lines() {
        let mut splitted = line.split_whitespace();
        let direction = splitted.next().unwrap();
        let step = splitted.next().unwrap().parse::<i32>().unwrap();
        match direction {
            "forward" => {
                horizon += step;
                depth += step * aim;
            },
            "up" => aim -= step,
            "down" => aim += step,
            _ => panic!(),
        }
    }
    println!("Day 02.01 : depth = {} - horizon = {}", depth, horizon);
    println!("Day 02.02 : aim {} for a total of {}", aim, depth * horizon);
}
