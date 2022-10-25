using Commander.Core.Commands;
using Commander.Core.Extensions;

namespace Commander.Tests;

public sealed class CommandTests
{
    [Fact]
    public void UseCommandForObjectTest()
    {
        var account = new Account(100);

        var movedMoneyOutOfAccount = new MovedMoneyOutOfAccount(20);

        Assert.Equal(100, account.Value);

        account.Action(movedMoneyOutOfAccount);

        Assert.Equal(80, account.Value);
    }

    [Fact]
    public void UseCommandsForObjectTest()
    {
        var account = new Account(100);

        var commands = new ICommand<Account>[]
        {
            new MovedMoneyOutOfAccount(20),
            new FillingUpAccount(30),
            new MovedMoneyOutOfAccount(60)
        };

        foreach (var command in commands) account.Action(command);

        Assert.Equal(50, account.Value);
    }

    [Fact]
    public void UseCommandForObjectsTest()
    {
        var accounts = new[]
        {
            new Account(100),
            new Account(1000),
            new Account(50)
        };

        var command = new MovedMoneyOutOfAccount(40);

        accounts.Action(command);

        Assert.Equal(60, accounts[0].Value);
        Assert.Equal(960, accounts[1].Value);
        Assert.Equal(10, accounts[2].Value);
    }

    [Fact]
    public void UseCommandsForObjectsTest()
    {
        var accounts = new[]
        {
            new Account(100),
            new Account(1000),
            new Account(50)
        };

        var command = new ICommand<Account>[]
        {
            new FillingUpAccount(100),
            new MovedMoneyOutOfAccount(45)
        };

        accounts.Action(command);

        Assert.Equal(155, accounts[0].Value);
        Assert.Equal(1055, accounts[1].Value);
        Assert.Equal(105, accounts[2].Value);
    }

    private sealed class Account
    {
        public Account(decimal value)
        {
            Value = value;
        }

        public decimal Value { get; set; }
    }

    private sealed class FillingUpAccount : ICommand<Account>
    {
        private readonly decimal _value;

        public FillingUpAccount(decimal value)
        {
            _value = value;
        }

        void ICommand<Account>.Execute(Account obj)
        {
            obj.Value += _value;
        }
    }

    private class MovedMoneyOutOfAccount : ICommand<Account>
    {
        private readonly decimal _value;

        public MovedMoneyOutOfAccount(decimal value)
        {
            _value = value;
        }

        void ICommand<Account>.Execute(Account obj)
        {
            obj.Value -= _value;
        }
    }
}