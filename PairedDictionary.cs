    //Paired dictionary of two types, both of which are used as a key to store the other
    //If used types are CLASSES they MUST OVERRIDE GetHashCode() and Equals() in order to
    //Properly function as keys in the dictionary. Makes 2-way link between unique objects.
    
    public class PairedDictionary<T1, T2>
    {
        Dictionary<T1, T2> a;
        Dictionary<T2, T1> b;

        public PairedDictionary()
        {
            a = new Dictionary<T1, T2>();
            b = new Dictionary<T2, T1>();
        }

        public void Add(T1 aval, T2 bval)
        {
            a.Add(aval, bval);
            b.Add(bval, aval);
        }

        public void Add(T2 bval, T1 aval)
        {
            a.Add(aval, bval);
            b.Add(bval, aval);
        }

        public T1 Get(T2 key)
        {
            return b[key];
        }

        public T2 Get(T1 key)
        {
            return a[key];
        }

        public void Set(T1 a, T2 b)
        {
            this.a[a] = b;
            this.b[b] = a;
        }

        public void Remove(T1 key)
        {
            b.Remove(Get(key));
            a.Remove(key);
        }

        public T1 this[T2 key]
        {
            get { return Get(key);  }
            set { Set(value, key); }
        }

        public T2 this[T1 key]
        {
            get { return Get(key); }
            set { Set(key, value); }
        }

        public void Remove(T2 key)
        {
            a.Remove(Get(key));
            b.Remove(key);
        }

        public Dictionary<T1, T2> GetDictionaryA()
        {
            return a;
        }

        public Dictionary<T2, T1> GetDictionaryB()
        {
            return b;
        }
    }
