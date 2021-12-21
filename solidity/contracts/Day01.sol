//SPDX-License-Identifier: Unlicense
pragma solidity ^0.8.0;

import "hardhat/console.sol";

contract Day01 {
    uint32 private _occurrence;
    uint32 private _position;
    uint32 private _lastRead;
    uint32 private _lastTotal;
    mapping(uint32 => uint32) private _window;

    function initPart01(uint32 _firstValue) public {
        _lastRead = _firstValue;
        _lastTotal = 2**32 - 1;
        _occurrence = 0;
    }

    function fillPart01(uint32 _value) public {
        if (_value > _lastRead) {
            _occurrence++;
        }
        _lastRead = _value;
    }

    function initPart02() public {
        _position = 0;
        _occurrence = 0;
    }

    function fillPart02(uint32 _value) public {
        uint32 _iteration = _position % 3;
        // I could cheat and fill the first 4 values at the init
        // and skip this "position test"
        if (_position > 2 && _window[_iteration] > _lastTotal) {
            _occurrence++;
        }
        _lastTotal = _window[_iteration];
        _window[_iteration] = _value;
        _window[(_position + 1) % 3] += _value;
        _window[(_position + 2) % 3] += _value;
        _position++;
    }

    function part01() public view returns (uint32) {
        console.log("Day 01.01 : ", _occurrence);
        return _occurrence;
    }

    function part02() public view returns (uint32) {
        console.log("Day 01.02 : ", _occurrence);
        return _occurrence;
    }
}
