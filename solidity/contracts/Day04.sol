//SPDX-License-Identifier: Unlicense
pragma solidity ^0.8.0;

import "hardhat/console.sol";

contract card {
    uint32 private _totalUnmarked;
    uint32[5][5] private _cardArray;
    uint32[5] private _incompleteLine = [5, 5, 5, 5, 5];
    uint32[5] private _incompleteColumn = [5, 5, 5, 5, 5];
    bool private _callLine;
    bool private _winningCard;

    function add(uint16 _x, uint16 _y, uint32 _value) public {
        require(_x < 6 && _y < 6);
        _cardArray[_x][_y] = _value;
        _totalUnmarked += _value;
    }

    function calledLine() public view returns (bool) {
        return _callLine;
    }

    function winningCard() public view returns (bool) {
        return _winningCard;
    }

    function totalUnmarked() public view returns (uint32) {
        return _totalUnmarked;
    }

    function draw(uint32 _value) public returns (bool) {
        if (_totalUnmarked == 0) {
            return false;
        }
        for(uint16 i = 0; i < 5; i++)
        {
            for(uint16 j = 0; j < 5; j++)
            {
                if (_cardArray[i][j] == _value) {
                    _totalUnmarked -= _value;
                    _incompleteLine[i] -= 1;
                    _incompleteColumn[j] -= 1;
                    if (_incompleteLine[i] == 0 && !_callLine) {
                        _callLine = true;
                    }
                    if ((_incompleteLine[i] == 0 || _incompleteColumn[j] == 0) && !_winningCard) {
                        _winningCard = true;
                    }
                    return true;
                }
            }
        }
        return false;
    }
}

contract Day04 {
    card[] private _cards;
    uint32 private _firstLineCall;
    uint32 private _lastWinner;
    bool private _endGame;
    uint32 _winningCards;
    mapping(uint32 => bool) private _wonCards;

    event LineCall(uint32 total);
    event LastBingoCall(uint32 total);

    function firstLineTotal() public view returns (uint32) {
        return _firstLineCall;
    }

    function lastWinnerTotal() public view returns (uint32) {
        return _lastWinner;
    }

    function fill(uint32[] memory _values) public {
        assert(_values.length == 25);
        card _newCard = new card();
        for(uint16 i = 0; i < 5; i++)
        {
            for(uint16 j = 0; j < 5; j++)
            {
                _newCard.add(i, j, _values[i * 5 + j]);
            }
        }
        _cards.push(_newCard);
    }

    function draw(uint32 _value) public {
        if (_endGame) {
            return;
        }
        for (uint16 i = 0; i < _cards.length; i++) {
            if (_cards[i].draw(_value)) {
                if (_firstLineCall == 0 && _cards[i].calledLine()) {
                    _firstLineCall = _cards[i].totalUnmarked() * _value;
                    emit LineCall(_firstLineCall);
                }
            }
            if (_cards[i].winningCard() && !_wonCards[i]) {
                _wonCards[i] = true;
                _winningCards += 1;
                if (_winningCards == _cards.length) {
                    _lastWinner = _cards[i].totalUnmarked() * _value;
                    _endGame = true;
                    emit LastBingoCall(_lastWinner);
                }
            }
        }
    }
}
