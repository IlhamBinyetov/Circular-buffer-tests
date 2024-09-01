namespace Circular_buffer
{
    public class CircularBuffer<T>
    {
        //////////////////////////////////////////////////////
        // You can add your own methods but .:[DO NOT]:.
        // change the signature of the provided methods
        //////////////////////////////////////////////////////
        ///
        private T[] buffer;
        private int head;
        private int tail;
        private bool isFull;

        public CircularBuffer(int capacity)
        {
            if (capacity <= 0) throw new ArgumentException("Capacity must be greater than zero.");
            buffer = new T[capacity];
            head = 0;
            tail = 0;
            isFull = false;
        }

        public T Read()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Buffer is empty.");
            var value = buffer[head];
            head = (head + 1) % buffer.Length;
            isFull = false;
            return value;
        }

        public void Write(T value)
        {
            if (isFull)
                throw new InvalidOperationException("Buffer is full.");

            buffer[tail] = value;
            tail = (tail + 1) % buffer.Length;

            if (tail == head)
                isFull = true;

        }

        public void Overwrite(T value)
        {
            if(isFull)
            {
                buffer[tail] = value;
                tail = (tail + 1) % buffer.Length;
                head = tail;
            }
            else
            {
                Write(value);
            }
        }

        public void Clear()
        {
            head = 0;
            tail = 0;
            isFull = false;
        }

        private bool IsEmpty()
        {
            return !isFull && head == tail;
        }
    }
}