using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circular_buffer
{
    public class CircularBufferTests
    {
        /////////////////////////////////////////////////////////
        // You can add more tests to validate your implementation
        /////////////////////////////////////////////////////////

        [Fact]
        public void Reading_empty_buffer_should_fail()
        {
            var buffer = new CircularBuffer<int>(capacity: 1);
            Assert.Throws<InvalidOperationException>(() => buffer.Read());
        }

        [Fact]
        public void Can_read_an_item_just_written()
        {
            var buffer = new CircularBuffer<int>(capacity: 1);
            buffer.Write(1);
            Assert.Equal(1, buffer.Read());
        }

        [Fact]
        public void Writing_to_full_buffer_should_fail()
        {
            var buffer = new CircularBuffer<int>(capacity: 1);
            buffer.Write(1);
            Assert.Throws<InvalidOperationException>(() => buffer.Write(2));
        }

        [Fact]
        public void Overwriting_in_a_full_buffer_should_replace_oldest_item()
        {
            var buffer = new CircularBuffer<int>(capacity: 2);
            buffer.Write(1);
            buffer.Write(2);
            buffer.Overwrite(3);
            Assert.Equal(2, buffer.Read());
            Assert.Equal(3, buffer.Read());
        }

        [Fact]
        public void Clearing_buffer_should_make_it_empty()
        {
            var buffer = new CircularBuffer<int>(capacity: 2);
            buffer.Write(1);
            buffer.Clear();
            Assert.Throws<InvalidOperationException>(() => buffer.Read());
        }
    }
}
