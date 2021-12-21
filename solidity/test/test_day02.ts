import { expect } from "chai";
import { ethers } from "hardhat";
import * as fs from "fs";
import * as readline from "node:readline";

describe("Day 02", function () {
  it("Fill for Part 02", async function () {
    const Day02 = await ethers.getContractFactory("Day02");
    const day02 = await Day02.deploy();
    await day02.deployed();

    const fileStream = fs.createReadStream('inc/day02.txt');

    const rl = readline.createInterface({
      input: fileStream,
      crlfDelay: Infinity
    });
  
    for await (const line of rl) {
      // Each line in input.txt will be successively available here as `line`.
      var splitted = line.split(' ');
      day02.fill(parseInt(splitted[1]), splitted[0]);
    }

    var [depth, horizon] = await day02.part01();
    expect(depth).to.equal(967791);
    expect(horizon).to.equal(1967);
    
    expect(await day02.part02()).to.equal(1903644897);
  });
});
