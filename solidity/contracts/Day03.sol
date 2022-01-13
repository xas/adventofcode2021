//SPDX-License-Identifier: Unlicense
pragma solidity ^0.8.0;

import "hardhat/console.sol";

contract Day03 {
    mapping(uint32 => uint32) private _zeroes;
    mapping(uint32 => uint32) private _ones;
    uint32[] private _forOxygen;
    uint32[] private _forDioxygen;
    uint32[] private _forWork;
    uint32[] private _forTheOnes;
    uint32[] private _forTheZeroes;
    uint32 private _oxygen;
    uint32 private _dioxygen;

    function fillPart01(uint32 _value) public {
        if (_value & 2048 > 0) {
            _forOxygen.push(_value);
        }
        else {
            _forDioxygen.push(_value);
        }

        uint32 _leftedValue = _value;
        for (uint16 i = 0; i < 12; i++) {
            if (_leftedValue % 2 == 0) {
                _zeroes[11 - i]++;
            }
            else {
                _ones[11 - i]++;
            }
            _leftedValue >>= 1;
        }
    }

    function part01() public view returns (uint32) {
        uint32 _gamma = 0;
        uint32 _epsilon = 0;
        for (uint32 position = 0; position < 12; position++) {
            if (_zeroes[position] < _ones[position]) {
                _gamma |= uint32(1 << (11 - position));
            }
            else {
                _epsilon |= uint32(1 << (11 - position));
            }
        }
        console.log("Day 03.01 : ", _gamma * _epsilon);
        return _gamma * _epsilon;
    }

    function part02() public view returns (uint32) {
        console.log("Day 03.01 : ", _oxygen * _dioxygen);
        return _oxygen * _dioxygen;
    }

    function part02Oxygen() public returns (uint32) {
        if (_forOxygen.length > _forDioxygen.length) {
            _forWork = _forOxygen;
        }
        else {
            _forWork = _forDioxygen;
        }

        for (uint32 position = 11; position > 0 && _forWork.length > 1; position--) {
            uint32 bitCheck = uint32(1 << position - 1);
            delete _forTheOnes;
            delete _forTheZeroes;
            for (uint32 i = 0; i < _forWork.length; i++) {
                if (_forWork[i] & bitCheck > 0) {
                    _forTheOnes.push(_forWork[i]);
                }
                else {
                    _forTheZeroes.push(_forWork[i]);
                }
            }
            if (_forTheOnes.length < _forTheZeroes.length) {
                _forWork = _forTheZeroes;
            }
            else {
                _forWork = _forTheOnes;
            }
        }

        _oxygen = _forWork[0];

        console.log("Day 03.01 (O2) : %s", _oxygen);
        return _oxygen;
    }

    function part02Dioxygen() public returns (uint32) {
        if (_forOxygen.length < _forDioxygen.length) {
            _forWork = _forOxygen;
        }
        else {
            _forWork = _forDioxygen;
        }

        for (uint32 position = 11; position > 0 && _forWork.length > 1; position--) {
            uint32 bitCheck = uint32(1 << position - 1);
            delete _forTheOnes;
            delete _forTheZeroes;
            for (uint32 i = 0; i < _forWork.length; i++) {
                if (_forWork[i] & bitCheck > 0) {
                    _forTheOnes.push(_forWork[i]);
                }
                else {
                    _forTheZeroes.push(_forWork[i]);
                }
            }
            if (_forTheOnes.length < _forTheZeroes.length) {
                _forWork = _forTheOnes;
            }
            else {
                _forWork = _forTheZeroes;
            }
        }

        _dioxygen = _forWork[0];

        console.log("Day 03.01 (CO2) : %s", _dioxygen);
        return _dioxygen;
    }
}
