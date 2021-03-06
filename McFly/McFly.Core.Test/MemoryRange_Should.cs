﻿using System;
using FluentAssertions;
using Xunit;

namespace McFly.Core.Test
{
    public class MemoryRange_Should
    {
        [Fact]
        public void Exhibit_Value_Equality_And_Comparison()
        {
            // arrange
            var m1 = new MemoryRange(0, 0);
            var m2 = new MemoryRange(0, 0);
            var m3 = new MemoryRange(1, 2);
            var m4 = new MemoryRange(1, 3);
            var m5 = new MemoryRange(2, 2);

            // act
            // assert
            (m1 == null).Should().BeFalse();
            (m1 == m1).Should().BeTrue();
            m1.Equals(null).Should().BeFalse();
            m1.Equals((object) m1).Should().BeTrue();
            m1.Equals((object) null).Should().BeFalse();
            m1.Equals(null).Should().BeFalse();
            m1.Equals(null);
            m1.Equals(new object()).Should().BeFalse();
            m1.CompareTo(m1).Should().Be(0);
            m1.Equals((object) m1).Should().BeTrue();
            m1.Equals(m1).Should().BeTrue();
            m1.Equals(m2).Should().BeTrue();
            m1.Equals((object) m2).Should().BeTrue();
            m1.CompareTo(m2).Should().Be(0);
            m1.CompareTo((object) m2).Should().Be(0);
            (m1 == m2).Should().BeTrue();
            (m1 != m4).Should().BeTrue();
            m1.GetHashCode().Should().Be(m2.GetHashCode());
            (m2 < m3).Should().BeTrue();
            (m2 <= m4).Should().BeTrue();
            (m4 > m3).Should().BeTrue();
            (m5 >= m4).Should().BeTrue();
            m1.CompareTo((object) m1).Should().Be(0);
            m1.CompareTo((object) null).Should().Be(1);
            m1.CompareTo(null).Should().Be(1);
            Action a = () => m1.CompareTo(new object());
            a.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Have_A_String_Representation_Like_The_Debugger()
        {
            new MemoryRange(0x123, 0xabc).ToString().Should().Be("123:ABC");
            new MemoryRange(0x123, 0xabc).DebuggerDisplay.Should().Be("123:ABC");
        }

        [Fact]
        public void Not_Allow_Invalid_Memory_Ranges()
        {
            // arrange
            Action throws = () => new MemoryRange(100, 0);

            // act
            // assert
            throws.Should()
                .Throw<ArgumentOutOfRangeException>("The low address cannot be larger than the high address");
        }

        [Fact]
        public void Not_Parse_Invalid_Input()
        {
            // arrange
            var l1 = "hello";
            var l2 = "-123:-24";
            Action throw1 = () => MemoryRange.Parse(l1);
            Action throw2 = () => MemoryRange.Parse(l2);

            // act
            // assert
            throw1.Should().Throw<FormatException>();
            throw2.Should().Throw<FormatException>();
        }

        [Fact]
        public void Parse_Both_Forms_Of_Input()
        {
            // arrange
            var l1 = "abcl100";
            var l2 = "ABCL100";
            var s1 = "abc:def";
            var s2 = "ABC:DEF";

            // act
            // assert
            MemoryRange.Parse(l1).Should().Be(new MemoryRange(0xabc, 0xbbc));
            MemoryRange.Parse(l1).Should().Be(new MemoryRange(0xabc, 0xbbc));
            MemoryRange.Parse(s1).Should().Be(new MemoryRange(0xabc, 0xdef));
            MemoryRange.Parse(s1).Should().Be(new MemoryRange(0xabc, 0xdef));

            // todo: make some 32 
        }

        [Fact]
        public void Return_The_Correct_Length()
        {
            new MemoryRange(0x10, 0x50).Length.Should().Be(0x40);
        }
    }
}